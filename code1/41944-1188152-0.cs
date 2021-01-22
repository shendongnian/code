    using System;
    using System.Collections.Generic;
    using Microsoft.FSharp.Collections;
    public static class FSharpInteropExtensions {
       public static FSharpList<TItemType> ToFSharplist<TItemType>(this IEnumerable<TItemType> myList)
       {
           return Microsoft.FSharp.Collections.ListModule.of_seq<TItemType>(myList);
       }
    
       public static IEnumerable<TItemType> ToEnumerable<TItemType>(this FSharpList<TItemType> fList)
       {
           return Microsoft.FSharp.Collections.SeqModule.of_list<TItemType>(fList);
       }
    }
