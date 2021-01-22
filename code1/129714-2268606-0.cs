    try {
        using (DisposableObject obj1 = GetDisposableObject()) {
            // do something
            
            using (DisposableObject obj2 = GetAnotherDisposableObject()) {
                // do something else
                
                using (DisposableObject obj3 = GetYetAnotherDisposableObject()) {
                    // do even more things
                    
                    // this code is now quite nested
                }
            }
        }
        
    } catch (SomeException ex) {
        // some error-handling magic
    }
