    public Models.DateClose SMAMethod (Queue<Models.DateClose> queue, int period)
    {
        decimal average, sum=0;
        Models.DateClose dateClose = null;
        for (int i = 0; i < period; i++)
        {
            dateClose = queue.Dequeue();
            
            if(dateClose != null)
                sum += dateClose.Close;
        }
        average = sum/period;
        dateClose.Close = average;  
        return dateClose;
    }
