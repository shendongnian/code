    void LateUpdate()
    {
      // (...)
      takeHiResShot = Input.GetKeyDown("k");
      if (takeHiResShot)
      {
        Vector3 startAngles = rift.transform.eulerAngles;
        for (int i = 1; i <= 20; ++i)
        {
          for (int j = 1; j <= 5; ++j)
          {
            //Setting transform.rotation is safer than setting transform.eulerAngles
            rift.transform.rotation = Quaternion.Euler((int)startAngles.x + i, (int)startAngles.y + j, (int)startAngles.z);
            Debug.Log(string.Format("i: {0}, j: {1}, eulerangles: {2}", i, j, rift.transform.eulerAngles));
            // (...)
          }
          //It is safe here because you didn't manipulate the value,
          //but Quaternion.Euler is still more advisable
          rift.transform.eulerAngles = startAngles;
        }
      }
    }
