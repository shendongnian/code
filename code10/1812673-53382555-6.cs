    string typeName; // why do we need this?
    private string SetDevType(int id)
    {
        string typeName = string.Empty;
        switch(id){
            case 1: typeName = "Something"; break;
            default: typeName = "Unknown";
        }
        return typeName;
    }
    
