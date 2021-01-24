    using UnityEngine;
    public class Class1 : MonoBehaviour
    {
    [SerializeField]
    private GameObject[] myPrefabs;
    public void ButtonEffect()
    {
        var go = InstantiatedPrefab();
        go.GetComponent<MyClass>().OnButtonEffect();
    }
    private GameObject InstantiatedPrefab()
    {
        var index = Random.Range(0, myPrefabs.Length);
        return Instantiate(myPrefabs[index]);
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
