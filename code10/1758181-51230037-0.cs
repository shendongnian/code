    public abstract class ProcotolControlBase {
        protected byte[] _up;
        protected byte[] _down;
        protected byte[] _left;
        protected byte[] _right;
        public void SetUpValue(int index,byte speed)
        {
            _up[index] = speed;
        }
        public void SetDownValue(int index, byte speed)
        {
            _down[index] = speed;
        }
    }
    public class ProcotolAControl : ProcotolControlBase
    {
        public ProcotolAControl() {
            _up = new byte[] { 0xff, 0x12, 0x03, 0x04 };
            _down = new byte[] { 0xff, 0x1a, 0x03, 0x05 };
            _left = new byte[] { 0xff, 0x10, 0x03, 0x02 };
            _right = new byte[] { 0xff, 0x02, 0x03, 0x06 };
        }
    }
    public class ProcotolBControl : ProcotolControlBase {
        public ProcotolBControl()
        {
            _up = new byte[] { 0xff, 0x12, 0x03, 0x04 };
            _down = new byte[] { 0xff, 0x1a, 0x03, 0x05 };
            _left = new byte[] { 0xff, 0x10, 0x03, 0x02 };
            _right = new byte[] { 0xff, 0x02, 0x03, 0x06 };
        }
    }
