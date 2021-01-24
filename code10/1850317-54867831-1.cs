using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ObjectCycler : MonoBehaviour {
  public float durationInSeconds = 5.0f;
  public GameObject[] objectsToCycle;
  int currentNdx = 0;
  void Start()
  {
    StartCoroutine(Cycle());
  }
  IEnumerator Cycle() 
  {
    for(;;) {
      objectsToCycle[currentNdx].SetActive(true);
      yield return new WaitForSeconds(durationInSeconds);
      objectsToCycle[currentNdx].SetActive(false);
      currentNdx = (currentNdx + 1) % objectsToCycle.Length;
    }
  }
}
Drag that script into any object. In the inspector expand the `objectsToCycle` property and set `size` to how many objects you want it to cycle. Drag the objects into it.
<img src="https://i.stack.imgur.com/rW2S3.png" width="340">
Advangates
1.  It's faster
2.  You can easily set the order. 
    Bill, Jill, Bob or Jill, Bill, Bob etc.
3.  The objects don't have to be children
4.  Objects can repeat
    Bill, Bob, Bill, Bob, Jill, Bob etc...
5.  You can rename objects and it won't break
6.  You can move objects in the hierarchy and it won't break
  [1]: https://i.stack.imgur.com/rW2S3.png
