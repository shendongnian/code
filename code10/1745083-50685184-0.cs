    using UnityEngine;
    using UnityEngine.UI;
    [RequireComponent(typeof(Button))]
    public class SwapObjectPositions : MonoBehaviour
    {
    public Transform[] boxTransform;
    public Button LeftButton;
    public Button RightButton;
    void Start()
    {
        if (LeftButton == null || RightButton == null)
        {
            Debug.Log("Button reference missing");
        }
        LeftButton.onClick.AddListener(LeftSwap);
        RightButton.onClick.AddListener(RightSwap);
        if (boxTransform.Length != 3 || boxTransform[0] == null || boxTransform[1] == null || boxTransform[2] == null)
        {
            Debug.Log("Boxes reference missing");
        }
    }
    public void LeftSwap()
    {
        // Swap Positions
        Vector3 tempPosition = boxTransform[0].position;
        boxTransform[0].position = boxTransform[1].position;
        boxTransform[1].position = tempPosition;
        // Swap Transform
        Transform tempTransform = boxTransform[0];
        boxTransform[0] = boxTransform[1];
        boxTransform[1] = tempTransform;
    }
    public void RightSwap()
    {
        // Swap Positions
        Vector3 tempPosition = boxTransform[1].position;
        boxTransform[1].position = boxTransform[2].position;
        boxTransform[2].position = tempPosition;
        // Swap Transform
        Transform tempTransform = boxTransform[1];
        boxTransform[1] = boxTransform[2];
        boxTransform[2] = tempTransform;
    }
    }
