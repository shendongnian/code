    public class SomeScriptOnGameObject : MonoBehaviour
    {
        private MyProperty<MyDoubleFloat> _myFirstVariable;
    
        private MyProperty<float> _mySecondVariable;
    
        public MyDoubleFloat MyFirstVariable
        {
            get => _myFirstVariable.Get();
            set => _myFirstVariable.Set(value);
        }
    
        public float MySecondVariable
        {
            get => _mySecondVariable.Get();
            set => _mySecondVariable.Set(value);
        }
    
        public SomeScriptOnGameObject()
        {
            _myFirstVariable = new MyProperty<MyDoubleFloat>
            {
                //configuration
            };
    
            _mySecondVariable = new MyProperty<float>
            {
                //configuration
            };
        }
    }
