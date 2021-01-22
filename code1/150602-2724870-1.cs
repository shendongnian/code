           foreach (IDnumber idCandidateMatch in IDnumbers)  
            { 
            if (IDCandidateMatch.ID == ID)
                {
                     StringBuilder myData = new StringBuilder();
                     myData.AppendLine(IDnumber.Name);   
                     myData.AppendLine(": ");   
                     myData.AppendLine(IDnumber.ID);   
                     myData.AppendLine(IDnumber.year);   
                     myData.AppendLine(IDnumber.class1);   
                     myData.AppendLine(IDnumber.class2);   
                     myData.AppendLine(IDnumber.class3);   
                     myData.AppendLine(IDnumber.class4);  
                     return myData;
        }
    }
    return "";
