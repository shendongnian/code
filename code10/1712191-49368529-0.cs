    // following script is attached to the character rotation Animator state
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    public class GenericState : StateMachineBehaviour {
        public bool _SnapEnabled;
        Quaternion _enterRotation;
        public float targetAngle_ = 180.0f;
	 
	    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex){
		    _enterRotation = animator.rootRotation;
        }
        override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex){
		    float normalizedTime_ = Mathf.Clamp(
                                   (stateInfo.normalizedTime - _matchMin) /
                                   (_matchMax - _matchMin), 0f, 1f);
		
		    if ( _SnapEnabled && normalizedTime_ > 0 ){
			    Quaternion snappedRotation_ = Quaternion.Euler(0, targetAngle_, 0);
			    Quaternion targetRotation_ = Quaternion.Lerp(_enterRotation,
                                                  snappedRotation_,
                                                  normalizedTime_);
             	
                animator.transform.position = animator.rootPosition;
		    	animator.transform.rotation = targetRotation_;
		    } else {
                animator.ApplyBuiltinRootMotion();
            }
	    }
    }
