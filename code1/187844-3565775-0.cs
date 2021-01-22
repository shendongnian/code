    System.DateTime punchIn = new System.DateTime(2010, 8, 25, 8, 0, 0);
    
    System.DateTime punchOut = new System.DateTime(2010, 8, 25, 16, 0, 0);
    
    System.TimeSpan diffResult = punchOut.Subtract(punchIn);
