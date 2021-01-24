     public partial class MainWindow : Window
        {
            List<KeyValuePair<string, int>> tracking = new List<KeyValuePair<string, int>>();
            List<KeyValuePair<string, int>> changeGiven = new List<KeyValuePair<string, int>>();
            List<decimal> coinItems = new List<decimal>();
    
            decimal valueSelected;
            decimal coinSoFar = 0;
            Hashtable coins = new Hashtable();
            Hashtable prices = new Hashtable();
    
            public MainWindow()
            {
                InitializeComponent();
    
                coins.Add("010", 0.10m);
                coins.Add("020", 0.20m);
                coins.Add("030", 0.30m);
                coins.Add("040", 0.40m);
                coins.Add("050", 0.50m);
    
                coinItems.Add(Convert.ToDecimal(coins["010"]));
                coinItems.Add(Convert.ToDecimal(coins["020"]));
                coinItems.Add(Convert.ToDecimal(coins["030"]));
                coinItems.Add(Convert.ToDecimal(coins["040"]));
                coinItems.Add(Convert.ToDecimal(coins["050"]));
    
                lbTodoList.ItemsSource = coinItems;
    
                prices.Add("100", 1.10m);
                prices.Add("120", 1.20m);
                prices.Add("130", 1.30m);
                prices.Add("140", 1.40m);
                prices.Add("150", 1.50m);
                prices.Add("160", 1.60m);
                prices.Add("170", 1.70m);
    
                List<decimal> priceItems = new List<decimal>();
                priceItems.Add(Convert.ToDecimal(prices["100"]));
                priceItems.Add(Convert.ToDecimal(prices["120"]));
                priceItems.Add(Convert.ToDecimal(prices["130"]));
                priceItems.Add(Convert.ToDecimal(prices["140"]));
                priceItems.Add(Convert.ToDecimal(prices["150"]));
                priceItems.Add(Convert.ToDecimal(prices["160"]));
                priceItems.Add(Convert.ToDecimal(prices["170"]));
    
                lbPrice.ItemsSource = priceItems;
            }
    
            private void lbTodoList_SelectionChanged(object sender, SelectionChangedEventArgs e)
            {
                var item = this.lbTodoList.SelectedItem?.ToString();
                if (item != null)
                {
                    if (!tracking.Select(x => x.Key == item).Any())
                    {
                        tracking.Add(new KeyValuePair<string, int>(item, 1));
                        Console.WriteLine(item + " has been selected once");
                    }
                    else
                    {
                        var currentItem = tracking.SingleOrDefault(x => x.Key == item);
                        var value = currentItem.Value;
                        tracking.Remove(currentItem);
                        value++;
                        tracking.Add(new KeyValuePair<string, int>(item, value));
                    }
    
                    var getIndex = item.Replace(".", "");
                    coinSoFar += Convert.ToDecimal(coins[getIndex]);
    
                    if (coinSoFar >= valueSelected)
                    {
                        StringBuilder coinsInserted = new StringBuilder();
                        foreach (var coinTracked in tracking)
                        {
                            coinsInserted.Append(coinTracked.Key + " x " + coinTracked.Value + "; ");
                        }
    
                        var difference = coinSoFar - valueSelected;
    
                        int coinDifferenceIndex = 0;
                        StringBuilder coinsReturned = new StringBuilder();
                        while (difference != 0)
                        {
                            var currentCoin = coinItems[coinDifferenceIndex];
                            difference -= currentCoin;
    
                            var currentItem = changeGiven.SingleOrDefault(x => x.Key == currentCoin.ToString());
                            if (currentItem.Key != null)
                            {
                                var value = currentItem.Value;
                                changeGiven.Remove(currentItem);
                                value++;
                                changeGiven.Add(new KeyValuePair<string, int>(currentItem.Key, value));
                            }
                            else
                            {
                                changeGiven.Add(new KeyValuePair<string, int>(currentCoin.ToString(), 1));
                            }
    
                            if (difference > currentCoin)
                            {
                                coinDifferenceIndex++;
                            }
                            else
                            {
                                coinDifferenceIndex = 0;
                            }
                        }
    
                        foreach (var coin in changeGiven)
                        {
                            coinsReturned.Append(coin.Key + " x " + coin.Value + "; ");
                        }
    
                        if(changeGiven.Any())
                        {
                            this.lblEnoughMoneyReached.Content = "Cost value has been met. Coins inserted: " + coinsInserted + ".Change given: " + coinsReturned;
                        }
                        else
                        {
                            this.lblEnoughMoneyReached.Content = "Cost value has been met. Coins inserted: " + coinsInserted;
                        }  
                    }
                }
                this.lbTodoList.SelectedItem = null;
            }
    
            private void lbPrice_SelectionChanged(object sender, SelectionChangedEventArgs e)
            {
                valueSelected = Convert.ToDecimal(this.lbPrice.SelectedItem?.ToString());
            }
        }
