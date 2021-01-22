    [Test, TestCaseSource( "GetActivities" )]
    public void ShouldBeSerializable( Activity activity )
    {
        var fieldInfos = activity.GetType().GetFields( BindingFlags.Public | BindingFlags.NonPublic 
                                                       | BindingFlags.Instance | BindingFlags.Static );
        
        fieldInfos.Where( fieldInfo => fieldInfo.Name != "parent" )
                  .ForEach( fieldInfo =>
                                {
                                    var fieldValue = fieldInfo.GetValue( activity );
    
                                    if ( fieldValue != null )
                                    {
                                        Serializer.Clone( fieldValue ); // no assert, throws exception if not serializable
                                    }
                                } );
    }
