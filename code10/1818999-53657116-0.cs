    namespace Extensions
    
    open System
    open System.Runtime.CompilerServices
    
    [<Extension>]
    module Extensions =
        [<Extension>]
        let Print(str : System.String) = Console.WriteLine(str)
    
        [<Extension>]
        let Blorp(o : System.Object) = Console.WriteLine("Hello World from an F# Extension Method!")
