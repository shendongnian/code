    using System;
    using System.Linq;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    
    public class WaitUntilComplete : MonoBehaviour {
    
    	// Use this for initialization
    	void Start () {
            StartCoroutine(WaitUntilAllAnimationsCompleted());
    	}
    
        IEnumerator WaitUntilAllAnimationsCompleted() {
            print("waiting started " + Time.time);
            yield return new WaitWhile(() => GetAllAnimationStates().Any(state => state.normalizedTime < 1f));
            print("waiting ended " + Time.time);
        }
    
        List<AnimatorStateInfo> GetAllAnimationStates() {
            List<AnimatorStateInfo> states = new List<AnimatorStateInfo>();
            var animatorList = GetComponentsInChildren<Animator>();
            foreach (var anim in animatorList) {
                for (int i = 0; i < anim.layerCount; ++i) {
                    states.Add(anim.GetCurrentAnimatorStateInfo(i));
                }
            }
            return states;
        }
    
    }
