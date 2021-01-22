    public class MethodCalls : IEnumerable<MethodInfo>
    {
        MethodBase _method;
        public MethodCalls(MethodBase method)
        {
            _method = method;
        }
        public IEnumerator<MethodInfo> GetEnumerator()
        {
            // see here: http://blogs.msdn.com/haibo_luo/archive/2005/10/04/476242.aspx
            ILReader reader = new ILReader(_method);
            foreach (ILInstruction instruction in reader) {
                CallInstruction call = instruction as CallInstruction;
                CallVirtInstruction callvirt = instruction as CallVirstInstruction;
                if (call != null)
                {
                    yield return ToMethodInfo(call);
                }
                else if (callvirt != null)
                {
                    yield return ToMethodInfo(callvirt);
                }
            }
        }
    }
    MethodInfo ToMethodInfo(CallInstruction instr) { /* ... */ }
    MethodInfo ToMethodInfo(CallVirtInstruction instr) { /* ... */ }
