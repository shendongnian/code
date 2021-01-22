    else 
    { 
        //ALWAYS SEND TO BOTTOM/END OF LIST. 
        if (string.IsNullOrEmpty(itemOne.Text) && string.IsNullOrEmpty(itemTwo.Text)) 
        {
            return 0;
        }
        else if (string.IsNullOrEmpty(itemOne.Text)) 
        {
            return -1;
        }
        else if (string.IsNullOrEmpty(itemTwo.Text)) 
        {
            return 1;
        }
    } 
