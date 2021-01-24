    public partial class QuantityPopUp : ContentPage
    {
        // ...
        private void btnOK_Clicked(object sender, EventArgs e)
        {
            Cart.Instance.Add(tempcodeofmenu, int.Parse(entQuantity.Text));
            Navigation.PushAsync(new OrderCart());
        }
        // ...
    }
    public partial class OrderCart : ContentPage
    {
        public OrderCart()
        {
            InitializeComponent ();
            MyCart.ItemsSource = Cart.Instance.GetAddedMeals();
        }
        // ...
    }
