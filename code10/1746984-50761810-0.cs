    #define v1
    #if v1
        private enum BoolFields { IsPipe, IsSomething }
    #elif v2
        private enum BoolFields { IsPipe, IsSomething, IsSomethingElse }
    #endif
