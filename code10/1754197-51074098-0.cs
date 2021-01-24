    public class PointRotator : MonoBehaviour
{
    bool rotating = false;
    float rate = 0;
    float angle;
    Vector3 point;
    Vector3 pivot;
    public void Rotate(Vector3 point, Vector3 pivot, float duration, float angle)
    {
        this.point = point;
        this.pivot = pivot;
        this.rate = angle/duration;
        this.angle = angle;
        rotating = true;
    }
    public void Update()
    {
        if (rotating)
        {
            // use quartonian.Lerp with Time.deltatime here
        //if(angle > quartonian angle){rotating = false)
        }
    }
