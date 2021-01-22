    .class public auto ansi serializable sealed BarFlag extends System.Enum
    {
        .custom instance void System.FlagsAttribute::.ctor()
        .custom instance void ComVisibleAttribute::.ctor(bool) = { bool(true) }
        .field public static literal valuetype BarFlag AllFlags = int32(0x3fff)
        .field public static literal valuetype BarFlag Foo1 = int32(1)
        .field public static literal valuetype BarFlag Foo2 = int32(0x2000)
        // and so on for all flags or enum values
        .field public specialname rtspecialname int32 value__
    }
