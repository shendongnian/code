    .try {
        // ...
      MidTry:
        // ...
        leave.s RestOfMethod
    }
    catch [mscorlib]System.Exception {
        leave.s MidTry  // branching back into try block!
    }
    RestOfMethod:
        // ...
