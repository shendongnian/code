    private string typeName;
    public void SetDevType(int id)
    {
        switch(id){
            case 1: typeName = "Something"; break;
            default: typeName = "Unknown";
        }
    }
    
