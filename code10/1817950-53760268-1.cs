    using System.Threading.Tasks;
    using UnityEngine;
    
    namespace Scripts
    {
        [RequireComponent(typeof(GrpcSetup))]
        public class AxeValuesConnectionInterface : MonoBehaviour
        {
            private GrpcSetup _grpcSetup;
            private float _timeElapsed;
            private int _loopController = 2;
            private int _loopController1 = 1;
            private int _loopController2 = 1;
            private int _counterLoop;
    
            private void Start()
            {
                _grpcSetup = GetComponent<GrpcSetup>();
            }
    
            private void Update()
            {    
                GrpcInitialization();
                GrpcUpdateMethods();
            }
    
            private void OnApplicationQuit()
            {
                Task.Run(_grpcSetup.ChannelShutDown);
            }
                 
            private void GrpcInitialization()
            {
                if (_loopController2 != 1) return;
    
                if (Instance.Ref.ConnectionInterface != Instance.Ci.Grpc) return;
    
                _grpcSetup.GrpcChannelInitialization();
                _loopController2 = 0;
            }
    
            private void GrpcUpdateMethods()
            {
                if (Instance.Ref.ConnectionInterface != Instance.Ci.Grpc || !Instance.Ref.FlowerIsPresent) return;
    
                Task.Run(() => _grpcSetup.GrpcUpdateMethod());
            }
        }
    }
