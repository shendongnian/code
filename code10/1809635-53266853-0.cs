    if (Session.Contents["ProductId"] != null)
            {
                GetProblemsByProduct();
            }
    
            if (Session.Contents["Branch"] != null)
            {
                GetProblemsByClient();
            }
