    public class EmployeeDB
    {
        public int ID{get;set;}
        public string Name {get;set;}
        public ing Age{get;set;}
        //both these would work
        public void Insert(Employee emp)
        public void Insert(string Name,int Age)
        //both these would work
        public void Update(Employee emp)
        public void Update(int ID,string Name,int Age)
        
        //works
        public void Delete(Employee emp)
        //WONT work
        public bool Delete(int empId)
        //will work
        public void Delete(int ID)
    }
----------
    <asp:ObjectDataSource 
        ID="ObjectDataSource1" 
        runat="server" 
        DataObjectTypeName="Employee"
        InsertMethod="Insert" 
        UpdateMethod="Update"
        DeleteMethod="Select" 
        TypeName="EmployeeDB" 
         DataKeyNames="ID">
    <DeleteParameters>
        <asp:Parameter Name="ID" Type="Int32" />
    </DeleteParameters>
    </asp:ObjectDataSource>
