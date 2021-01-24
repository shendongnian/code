    // Require an ApplicationException - derived types fail!
    Assert.Throws( typeof(ApplicationException), code );
    Assert.Throws<ApplicationException>()( code );
    // Allow both ApplicationException and any derived type
    Assert.Throws( Is.InstanceOf( typeof(ApplicationException), code );
    Assert.Throws( Is.InstanceOf<ApplicationException>(), code );
    // Allow both ApplicationException and any derived type
    Assert.Catch<ApplicationException>( code );
    // Allow any kind of exception
    Assert.Catch( code )
 
