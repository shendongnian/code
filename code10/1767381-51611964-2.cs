    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    
    public class RightJoystickPlayerController : MonoBehaviour
    {
        public RightJoystick rightJoystick;
        public Transform rotationTarget;
        private Vector3 rightJoystickInput;
        public bool flipRot = true;
        public static float angle;
    
        private float horizontal;
        private float vertical;
    
        private List<Quaternion> lastRotations = new List<Quaternion>();
    
        private void Start()
        {
            for (int i = 0; i < 16; i++)
            {
                lastRotations.Add(Quaternion.identity);
            }
        }
    
        private void Update()
        {
            lastRotations.Add(rightJoystick.GetInputDirection());
            while (lastRotations.Count > 16)
            {
                lastRotations.RemoveAt(0);
            }
    
            Quaternion quatA = lastRotations[0];
            Quaternion quatB = lastRotations[1];
            Quaternion quatC = lastRotations[2];
            Quaternion quatD = lastRotations[3];
            Quaternion quatE = lastRotations[4];
            Quaternion quatF = lastRotations[5];
            Quaternion quatG = lastRotations[6];
            Quaternion quatH = lastRotations[7];
            Quaternion quatI = lastRotations[8];
            Quaternion quatJ = lastRotations[9];
            Quaternion quatK = lastRotations[10];
            Quaternion quatL = lastRotations[11];
            Quaternion quatM = lastRotations[12];
            Quaternion quatN = lastRotations[13];
            Quaternion quatO = lastRotations[14];
            Quaternion quatP = lastRotations[15];
    
            Quaternion quatAB = Quaternion.Lerp(quatA, quatB, 0.5f);
            Quaternion quatCD = Quaternion.Lerp(quatC, quatD, 0.5f);
            Quaternion quatEF = Quaternion.Lerp(quatE, quatF, 0.5f);
            Quaternion quatGH = Quaternion.Lerp(quatG, quatH, 0.5f);
            Quaternion quatIJ = Quaternion.Lerp(quatI, quatJ, 0.5f);
            Quaternion quatKL = Quaternion.Lerp(quatK, quatL, 0.5f);
            Quaternion quatMN = Quaternion.Lerp(quatM, quatN, 0.5f);
            Quaternion quatOP = Quaternion.Lerp(quatO, quatP, 0.5f);
    
            Quaternion quatABCD = Quaternion.Lerp(quatAB, quatCD, 0.5f);
            Quaternion quatEFGH = Quaternion.Lerp(quatEF, quatGH, 0.5f);
            Quaternion quatIJKL = Quaternion.Lerp(quatIJ, quatKL, 0.5f);
            Quaternion quatMNOP = Quaternion.Lerp(quatMN, quatOP, 0.5f);
    
            Quaternion quatABCDEFGH = Quaternion.Lerp(quatABCD, quatEFGH, 0.5f);
            Quaternion quatIJKLMNOP = Quaternion.Lerp(quatIJKL, quatMNOP, 0.5f);
    
            Quaternion quatABCDEFGHIJKLMNOP = Quaternion.Lerp(quatABCDEFGH, quatIJKLMNOP, 0.5f);
    
            horizontal = rightJoystickInput.x;
            vertical = rightJoystickInput.y;
            angle = Mathf.Atan2(horizontal, vertical) * Mathf.Rad2Deg;
            angle = flipRot ? -angle : angle;
            rotationTarget.rotation = quatABCDEFGHIJKLMNOP;
        }
    }
