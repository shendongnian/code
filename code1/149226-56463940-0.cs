    public static class MethodInfoUtil
    {
        public static int NbOfInnerCalls(this MethodInfo mi)
        {
            return mi.GetInstructions().Count(
                instruction => instruction.OpCode.FlowControl == FlowControl.Call);
        }
    }
