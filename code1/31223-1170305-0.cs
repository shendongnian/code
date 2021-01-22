    /// Return three functions that can be used to implement the .NET Asynchronous 
    /// Programming Model (APM) for a given asynchronous computation.
    /// 
    /// The functions should normally be published as members with prefix 'Begin',
    /// 'End' and 'Cancel', and can be used within a type definition as follows:
    /// <c>
    ///   let beginAction,endAction,cancelAction = Async.AsBeginEnd computation
    ///   member x.BeginSomeOperation(callback,state) = beginAction(callback,state)
    ///   member x.EndSomeOperation(iar) = endAction(iar)
    ///   member x.CancelSomeOperation(iar) = cancelAction(iar)
    /// </c>
    ///
    /// The resulting API will be familiar to programmers in other .NET languages and 
    /// is a useful way to publish asynchronous computations in .NET components.
    static member AsBeginEnd : computation:Async<'T> ->                     // '
                                 // The 'Begin' member
                                 (System.AsyncCallback * obj -> System.IAsyncResult) * 
                                 // The 'End' member
                                 (System.IAsyncResult -> 'T) *              // '
                                 // The 'Cancel' member
                                 (System.IAsyncResult -> unit)
