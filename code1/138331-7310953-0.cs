    // ReSharper disable InconsistentNaming
    // ReSharper disable PartialMethodWithSinglePart
    // ReSharper disable PartialTypeWithSinglePart
    <#
        // This is the "model" that is "what" we would like to generate
        var classDefs = new []
        {
            new ClassDefinition
            {
                Name = "A",
                Properties = new []
                {
                    P ("int"    , "Id"      ),
                    P ("string" , "Name"    ),
                    P ("B"      , "FirstB"  , listenToChanges:true  ),
                    P ("B"      , "SecondB" , listenToChanges:true  ),
                    P ("B"      , "ThirdB"  , listenToChanges:true  ),
                },
            },
            new ClassDefinition
            {
                Name = "B",
                Properties = new []
                {
                    P ("int"    , "Id"      ),
                    P ("string" , "Name"    ),
                },
            },
        };
    #>
    namespace SO
    {
        using System;
        using System.ComponentModel;
    <#
        // This part is the template ie "how" the model will be transformed into code
        foreach (var classDef in classDefs)
        {
    #>        
        // ------------------------------------------------------------------------
        /// <summary>
        /// class <#=classDef.Name#> (implements INotifyPropertyChanged)
        /// </summary>
        public partial class <#=classDef.Name#> : INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged (string name)
            {
                PropertyChangedEventHandler handler = PropertyChanged;
                if (handler != null) 
                {
                    handler (this, new PropertyChangedEventArgs (name));
                }
            }
    <#
            foreach (var propertyDef in classDef.Properties)
            {
    #>
            // --------------------------------------------------------------------
            /// <summary>
            /// Gets or sets property <#=propertyDef.Name#> (<#=propertyDef.Type#>)
            /// </summary>
            public <#=propertyDef.Type#> <#=propertyDef.Name#>
            { 
                get { return <#=propertyDef.FieldName#>; } 
                set 
                { 
                    if (<#=propertyDef.FieldName#> == value) 
                    { 
                        return; 
                    } 
    <#
                if (propertyDef.ListenToChanges)
                {
    #>
                    if (<#=propertyDef.FieldName#> != null) 
                    { 
                        <#=propertyDef.FieldName#>.PropertyChanged -= <#=propertyDef.ListenerName#>;
                    } 
 
                    <#=propertyDef.FieldName#> = value; 
 
                    if (<#=propertyDef.FieldName#> != null)  
                    {
                        <#=propertyDef.FieldName#>.PropertyChanged += <#=propertyDef.ListenerName#>; 
                    }
    <#
                }
                else
                {
    #>
                    <#=propertyDef.FieldName#> = value; 
    <#
                }
    #>
                    <#=propertyDef.EventName#> ();
                    OnPropertyChanged("<#=propertyDef.Name#>");  
 
                } 
            } 
            // --------------------------------------------------------------------
            <#=propertyDef.Type#> <#=propertyDef.FieldName#>; 
            // --------------------------------------------------------------------
            partial void <#=propertyDef.EventName#> ();
            // --------------------------------------------------------------------
    <#
                if (propertyDef.ListenToChanges)
                {
    #>
            void <#=propertyDef.ListenerName#> (object sender, PropertyChangedEventArgs e)
            {
                Console.WriteLine (
                    "Instance of <#=classDef.Name#> detected a change of <#=propertyDef.Name#>.{0}", 
                    e.PropertyName
                    );
                <#=propertyDef.EventName#> ();
            }
            // --------------------------------------------------------------------
    <#
                }
            }
    #>
        }
        // ------------------------------------------------------------------------
    <#
        }
    #>
    }
    <#+
        class ClassDefinition
        {
            public string Name;
            public PropertyDefinition[] Properties;
        }
        class PropertyDefinition
        {
            public string Type;
            public string Name;
            public bool ListenToChanges;
            public string FieldName 
            {
                get
                {
                    return "_" + Name;
                }
            }
            public string ListenerName 
            {
                get
                {
                    return Name + "_Listener";
                }
            }
            public string EventName 
            {
                get
                {
                    return "Change_" + Name;
                }
            }
        }
        PropertyDefinition P (string type, string name, bool listenToChanges = false)
        {
            return new PropertyDefinition
                {
                    Type = type ?? "<NO_TYPE>",
                    Name = name ?? "<NO_NAME>",
                    ListenToChanges = listenToChanges,
                };
        }
    #>
