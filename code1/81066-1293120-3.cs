    class Test
    {
        static void Main()
        {
            StringBuilder builder = new StringBuilder();
            PassByRef(ref builder);
            // builder now refers to the StringBuilder
            // constructed in PassByRef
            PassByValueChangeContents(builder);
            // builder still refers to the same StringBuilder
            // but then contents has changed
            PassByValueChangeParameter(builder);
            // builder still refers to the same StringBuilder,
            // not the new one created in PassByValueChangeParameter
        }
        static void PassByRef(ref StringBuilder x)
        {
            x = new StringBuilder("Created in PassByRef");
        }
        static void PassByValueChangeContents(StringBuilder x)
        {
            x.Append(" ... and changed in PassByValueChangeContents");
        }
        static void PassByValueChangeParameter(StringBuilder x)
        {
            // This new object won't be "seen" by the caller
            x = new StringBuilder("Created in PassByValueChangeParameter");
        }
    }
