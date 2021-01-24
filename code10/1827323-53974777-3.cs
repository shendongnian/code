    using UnityEngine;
    public class Class1 : MonoBehaviour
    {
    [SerializeField]
    private GameObject[] myPrefabs;
    private GameObject myCurrentPrefab;
    public void ButtonEffect()
    {
        InstantiatePrefab();      
        myCurrentPrefab.GetComponent<MyClass>().OnButtonEffect();
    }
    private void InstantiatePrefab()
    {
        var myIndex = Random.Range(0, myPrefabs.Length);
        var prefab = myPrefabs[myIndex];
        myCurrentPrefab = Instantiate(prefab);
    }
    }
    using System.Collections;
    using UnityEngine;
    public class MyClass : MonoBehaviour
    {
    private SpriteRenderer mySprite;
    private void Start()
    {
        mySprite = GetComponent<SpriteRenderer>();
    }
    public void OnButtonEffect()
    {
        StartCoroutine(FadeOut(mySprite, 3));
    }
    private IEnumerator FadeOut(SpriteRenderer spriteToFade, float duration)
    {
        print("FadeOut");
        yield return 0;
        
    }
    }
