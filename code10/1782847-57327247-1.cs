 csharp
    public class Cart : AggregateRoot
    {
        private const int maxQuantityPerProduct = 10;
        private const decimal minCartAmountForCheckout = 50m;
        private readonly List<CartItem> items = new List<CartItem>();
        public Cart(EntityId customerId) : base(customerId)
        {
            CustomerId = customerId;
            IsClosed = false;
        }
        public EntityId CustomerId { get; }
        public bool IsClosed { get; private set; }
        public IReadOnlyList<CartItem> Items => items;
        public decimal TotalAmount => items.Sum(item => item.TotalAmount);
        public Result CanAdd(Product product, Quantity quantity)
        {
            var newQuantity = quantity;
            var existing = items.SingleOrDefault(item => item.Product == product);
            if (existing != null)
                newQuantity += existing.Quantity;
            if (newQuantity > maxQuantityPerProduct)
                return Result.Fail("Cannot add more than 10 units of each product.");
            return Result.Ok();
        }
        public void Add(Product product, Quantity quantity)
        {
            CanAdd(product, quantity)
                .OnFailure(error => throw new Exception(error));
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].Product == product)
                {
                    items[i] = items[i].Add(quantity);
                    return;
                }
            }
            items.Add(new CartItem(product, quantity));
        }
        public void Remove(Product product)
        {
            var existing = items.SingleOrDefault(item => item.Product == product);
            if (existing != null)
                items.Remove(existing);
        }
        public void Remove(Product product, Quantity quantity)
        {
            var existing = items.SingleOrDefault(item => item.Product == product);
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].Product == product)
                {
                    items[i] = items[i].Remove(quantity);
                    return;
                }
            }
            if (existing != null)
                existing = existing.Remove(quantity);
        }
        public Result CanCloseForCheckout()
        {
            if (IsClosed)
                return Result.Fail("The cart is already closed.");
            if (TotalAmount < minCartAmountForCheckout)
                return Result.Fail("The total amount should be at least 50 dollars in order to proceed to checkout.");
            return Result.Ok();
        }
        public void CloseForCheckout()
        {
            CanCloseForCheckout()
                .OnFailure(error => throw new Exception(error));
            IsClosed = true;
            AddDomainEvent(new CartClosedForCheckout(this));
        }
        public override string ToString()
        {
            return $"{CustomerId}, Items {items.Count}, Total {TotalAmount}";
        }
    }
And the class for the Items:
 csharp
    public class CartItem : ValueObject<CartItem>
    {
        internal CartItem(Product product, Quantity quantity)
        {
            Product = product;
            Quantity = quantity;
        }
        public Product Product { get; }
        public Quantity Quantity { get; }
        public decimal TotalAmount => Product.UnitPrice * Quantity;
        public CartItem Add(Quantity quantity)
        {
            return new CartItem(Product, Quantity + quantity); 
        }
        public CartItem Remove(Quantity quantity)
        {
            return new CartItem(Product, Quantity - quantity);
        }
        public override string ToString()
        {
            return $"{Product}, Quantity {Quantity}";
        }
        protected override bool EqualsCore(CartItem other)
        {
            return Product == other.Product && Quantity == other.Quantity;
        }
        protected override int GetHashCodeCore()
        {
            return Product.GetHashCode() ^ Quantity.GetHashCode();
        }
    }
Some important things to note:
1. `Cart` and `CartItem` are one thing. They are loaded from the database as a single unit, then persisted back as such, in one transaction;
2. Data and Operations (behavior) are close together. This is actually not a DDD rule or guideline, but an Object Oriented programming principle. This is what OO is all about;
3. Every operation someone can do with the model is expressed as a method in the aggregate root, and the aggreate root takes care of it all when it comes to dealing with its internal objects. It controls everything, every operation must go through the root;
4. For every operation that can potentially go wrong, there's a validation method. For example, you have the `CanAdd` and the `Add` methods. Consumers of this class should first call `CanAdd` and propagate possible errors up to the user. If `Add` is called without prior validation, than `Add` will check with `CanAdd` and throw an exception if any invariant were to be violated, and throwing an exception is the right thing to do here because getting to `Add` without first checking with `CanAdd` represents a bug in the software, an error by committed the programmers;
5. `Cart` is an entity, it has an Id, but `CartItem` is a ValueObject an has no Id. A customer could repeat a purchase with the same items and it would still be a different Cart, but a CartItem with the same properties (quantity, price, itemname) is always the same - it is the combination of its properties that make up its identity.
So, consider the rules of my domain:
* The user can't add more than 10 units of each product to the cart;
* The user can only proceed to checkout if they have at least 50 USD of products in the cart.
These are enforced by the aggregate root and there's no way of misusing the classes in any way that would allow breaking the invariants.
You can see the full model here: [Shopping Cart Model](https://github.com/phillippelevidad/ddd-models/tree/master/ShoppingCart)
----------
## Back to your question
> Updating Basket (maybe some items' quantity has been changed)
Have a method in the `Basket` class that will be responsible for operating changes to the basket items (adding, removing, changing quantity).
> Adding/Setting new Order
It seems like an Order would reside in another Bounded Context. In that case, you would have a method like `Basket.ProceedToCheckout` that would mark itself as closed and would propagate a DomainEvent, which would in turn be picked up in the Order Bounded Context and an Order would be added/created.
But if you decide that the Order in your domain is part of the same BC as the Basket, you can have a DomainService that will deal with two aggregates at once: it would call `Basket.ProceedToCheckout` and, if no error is thrown, it would the create an `Order` aggregate from it. Note that this is an operation that spans two aggregates, and so it has been moved from the aggregate to the DomainService.
Note that a database transaction is not needed here in order the ensure the correctness of the state of the domain.
You can call `Basket.ProceedToCheckout`, which would change its internal state by setting a `Closed` property to `true`. Then the creation of the Order could go wrong and you would not need to rollback the Basket.
You could fix the error in the software, the customer could attempt to checkout once more and your logic would simply check whether the Basket is already closed and has a corresponding Order already. If not, it would carry out only the necessary steps, skipping those already completed. This is what we call **Idempotency**.
> Deleting the basket(or flag as deleted in DB)
You should really think more about that. Talk to the domain experts, because we don't delete anything the real world, and you probably shouldn't delete a basket in your domain. Because this is information that most likely has value to the business, like knowing which baskets were abandoned and then the marketing dept. could promote an action with discounts to bring back these customers so that they can buy.
I recommend you read this article: [Don't Delete - Just Don't](http://udidahan.com/2009/09/01/dont-delete-just-dont/), by Udi Dahan. He dives deep in the subject.
> Paying via CreditCard using specific Payment gateway
Payment Gateway is infrastructure, your Domain should not know anything about it (even interfaces should be declared in another layer). In terms of software architecture, more specifically in the Onion Architecture, I recommend you define these classes:
 csharp
    namespace Domain
    {
        public class PayOrderCommand : ICommand
        {
            public Guid OrderId { get; }
            public PaymentInformation PaymentInformation { get; }
            public PayOrderCommand(Guid orderId, PaymentInformation paymentInformation)
            {
                OrderId = orderId;
                PaymentInformation = paymentInformation;
            }
        }
    }
    namespace Application
    {
        public class PayOrderCommandHandler : ICommandHandler<PayOrderCommand>
        {
            private readonly IPaymentGateway paymentGateway;
            private readonly IOrderRepository orderRepository;
            public PayOrderCommandHandler(IPaymentGateway paymentGateway, IOrderRepository orderRepository)
            {
                this.paymentGateway = paymentGateway;
                this.orderRepository = orderRepository;
            }
            public Result Handle(PayOrderCommand command)
            {
                var order = orderRepository.Find(command.OrderId);
                var items = GetPaymentItems(order);
                
                var result = paymentGateway.Pay(command.PaymentInformation, items);
                if (result.IsSuccess)
                {
                    order.MarkAsPaid();
                    orderRepository.Save(order);
                }
                return Result.Ok();
            }
            private List<PaymentItems> GetPaymentItems(Order order)
            {
                // TODO: convert order items to payment items.
            }
        }
        public interface IPaymentGateway
        {
            Result Pay(PaymentInformation paymentInformation, IEnumerable<PaymentItems> paymentItems);
        }
    }
I hope this has given you some insight.
