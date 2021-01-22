    public int LinesPerPage    
    {     
       get   
       {      
          return (int)(this.ClientSize.Height / this.Font.Height);
       }
    }
