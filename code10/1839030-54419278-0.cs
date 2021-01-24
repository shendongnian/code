public class VuzixSelectButton : MonoBehaviour
{  
    KeyCode DPAD_CENTER = (KeyCode)10;
    void Update ()
    {
        VuzixSelect();   
    }
    /// <summary>
    /// Detects Vuzix M300 select button presses
    /// </summary>
    private void VuzixSelect()
    {
        if (SystemInfo.deviceModel.ToLower().Contains("vuzix"))
        {
            if (Input.GetKeyDown(DPAD_CENTER))
            {
                var es = EventSystem.current;
                GameObject obj = es.currentSelectedGameObject;
                ExecuteEvents.Execute(obj, new PointerEventData(EventSystem.current), ExecuteEvents.pointerClickHandler);
            }
        }
    }
}
