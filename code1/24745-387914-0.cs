// No need to change the Transaction class
public class Transaction
{
    private double _margin;
    private Product _product;
    private Client _client;
    public double Margin { get; }
    public Product Product { get; }
    public Client Client { get; }
    public Transaction(Product p, Client c)
    {
        _product = p;
        _client = c;
    }
    public void CalculateMargin()
    {
        _margin = _product.MarginCalculator.CalculateMargin();
    }
}
