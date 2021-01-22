    [Column(Name="ColumnName", DbType="varchar(10) NULL", CanBeNull=true)]
    private string MyPropertyString {
        get { /* serialize MyProperty yourself */ }
        set { /* deserialize MyProperty yourself */ }
    }
    public MyCustomType MyProperty {get;set;}
