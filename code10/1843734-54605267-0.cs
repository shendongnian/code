csharp
void Update()
{
  if (Input.GetKey(KeyCode.W)) // Check if key W is pressed
  {
    var force = Input.GetKey(KeyCode.LeftCtrl) ? 1000 : 500; // Check if key left ctrl is ALSO pressed. If it is the force is 1000, else the force is 500
    rb.AddForce(0, 0, force * Time.deltaTime);
  }
}
