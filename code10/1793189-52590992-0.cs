    public PersonData : IPerson // and thus also IPublicPersonData and ISecretPersonData
    {
         // this PersonData contains both public and secret data:
         public IPublicPersonData PublicPersonData {get; set;}
         public ISecretPersnData SecretPersonData {get; set;}
         // implementation of IPerson / IPublicPersonData / ISecretPersonData
         int PersonId
         { 
             get {return this.PublicPersonData.Id; }
             set
             {   // update both Ids
                 this.PublicPersonData.Id = value;
                 this.SecreatPersonData.Id = value;
             }
         }
         public string Name
         {
            get { return this.PublicPersonData.Name; },
            set {this.PublicPersonData.Name = value;}
         }
         public decimal AnnualSalary
         {
             get {return this.SecretPersonData.AnnualSalary;},
             set {this.SecretPersnData.AnnualSalary = value;
         }
    }
