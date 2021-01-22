    [Table(Name="dbo.Client")]
    [DataContract(IsReference=true)]
    public partial class Client: INotifyPropertyChanging, INotifyPropertyChanged
    {
      ..//
      private EntitySet<ClEmp> _ClEmp;
      [Association(N...)]
      [DataMember(Order=70, EmitDefaultValue=false)]
      public EntitySet<ClEmp> ClEmps
    }
