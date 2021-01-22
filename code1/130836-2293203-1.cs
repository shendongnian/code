public bool Foo{
    get{ return this._foo; }
    set{ if (this._foo != value){ 
                this._foo = value; 
         }
       }
}
public bool ShouldSerializeFoo(){
    return true; // The property will be persisted in the designer-generated code
                 // Check in Form.Designer.cs...
}
