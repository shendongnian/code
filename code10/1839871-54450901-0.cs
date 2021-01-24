    using UnityEngine;
    using UnityEngine.EventSystems;
    
    public class Manager : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
    Vector2 pos1;
    public GameObject pos2;
    private bool canMove;
    
    void Start()
    {
        pos1 = transform.position;
        canMove = true;
    }
    
    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log(eventData);
    }
    
    public void OnDrag(PointerEventData eventData)
    {
        if (canMove)
            transform.position = Input.mousePosition;
    }
     
    public void OnEndDrag(PointerEventData eventData)
    {
        float distance = Vector3.Distance(transform.position, pos2.transform.position);
        if (distance < 50)
        {
            transform.position = pos2.transform.position;
            transform.localScale = pos2.transform.localScale;
            canMove = false;
        }
        else
        {
            transform.position = pos1;
        }
    }
    }
