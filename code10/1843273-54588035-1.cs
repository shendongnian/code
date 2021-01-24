    public class TestModeQuestionUI : MonoBehaviour
    {
        private int a, b;
    
        public void SetQuestionLabel(int a, int b)
        {
            this.a = a;
            this.b = b;
            valueA.text = a + " " + b + "  = ";        
        }
    }
