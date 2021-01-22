    public class Entity
    {
       public class Builder
       {
         private int _field1;
         private int _field2;
         private int _field3;
    
         public Builder WithField1(int value) { _field1 = value; return this; }
         public Builder WithField2(int value) { _field2 = value; return this; }
         public Builder WithField3(int value) { _field3 = value; return this; }
    
         public Entity Build() { return new Entity(_field1, _field2, _field3); }
       }
    
       private int _field1;
       private int _field2;
       private int _field3;
    
       private Entity(int field1, int field2, int field3) 
       {
         // Set the fields.
       }
    
       public int Field1 { get { return _field1; } }
       public int Field2 { get { return _field2; } }
       public int Field3 { get { return _field3; } }
    
       public static Builder Build() { return new Builder(); }
    }
