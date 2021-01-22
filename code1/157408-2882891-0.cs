     private string encryptedProperty2;
     public string MyProperty2
     {
          get { return this.Decrypt( this.encryptedProperty2 ); }
          set { this.encryptedProperty2 = this.Encrypt( value ); }
     }
     private void Init()
     {
         ...
         this.encryptedProperty2 = ... read from file ...
         ...
     }
     public void Save()
     {
          ...
          writer.Write( this.encryptedProperty2 );
          ...
     }
