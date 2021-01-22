    var properties = this.GetType()
                         .GetProperties()
                         .Where( p => p.Name.StartsWith("Value") )
                         .Select( p => new {
                               Name = p.Name,
                               Value = p.GetValue( this, null )
                          });    
