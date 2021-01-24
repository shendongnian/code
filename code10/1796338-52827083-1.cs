    public class PunCamera : MonoBehaviour
    {
        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.Space)) 
            {
                OtherPlayerBlur();
            }
        }
        public void OtherPlayerBlur()
        {
            //Get the PhotonView in the camera object and call the RPC
            var _photonView = this.GetComponent<PhotonView>();
            _photonView.RPC("PunCameraBlur", PhotonTarget.Others);
        }
        [PunRPC]
        private void PunCameraBlur()
        {
            // Camera Blur Method Call
        }
    }
