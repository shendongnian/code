    public struct BigStruct
    {
      public int A, B, C, D, E, F, G, H, J, J, K, L, M, N, O, P;
    }
    
    SomeMethod(instanceOfBigStruct); // A copy is made of this 64-byte struct.
    
    SomeOtherMethod(out instanceOfBigStruct); // No copy is made
