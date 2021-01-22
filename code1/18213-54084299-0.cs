    private static void TryToDecimal(string str, Action<decimal> action)
    {
            if (decimal.TryParse(str, out decimal ret))
            {
                action(ret);
            }
            else
            {
                //do something you want
            }
    }
    TryToDecimal(strList[5], (x) => { st.LastTradePrice = x; });
    TryToDecimal(strList[3], (x) => { st.LastClosedPrice = x; });
    TryToDecimal(strList[6], (x) => { st.TopPrice = x; });
    TryToDecimal(strList[7], (x) => { st.BottomPrice = x; });
    TryToDecimal(strList[10], (x) => { st.PriceChange = x; });
