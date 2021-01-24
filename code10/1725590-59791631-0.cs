using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using TBEasyWebCam;
public class ARManager : MonoBehaviour
{
#if (UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR
	bool isTorchOn = false;
#endif
	public void toggleTorch()
    {
#if (UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR
		if (EasyWebCam.isActive) {
			if (isTorchOn) {
				//torchImage.sprite = torchOffSprite;
				EasyWebCam.setTorchMode (TBEasyWebCam.Setting.TorchMode.Off);
			} else {
				//torchImage.sprite = torchOnSprite;
				EasyWebCam.setTorchMode (TBEasyWebCam.Setting.TorchMode.On);
			}
			isTorchOn = !isTorchOn;
		}
#endif
    }
	
}
