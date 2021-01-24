    void LateUpdate()
    {
      // (...)
      takeHiResShot = Input.GetKeyDown("k");
      if (takeHiResShot)
      {
        Vector3 startAngles = rift.transform.eulerAngles;
        Vector3Int intStartAngles = new Vector3Int((int)startAngles.x, (int)startAngles.y, (int)startAngles.z);
        for (int i = 1; i <= 20; ++i)
        {
          for (int j = 1; j <= 5; ++j)
          {
            //Setting transform.rotation is safer than setting transform.eulerAngles
            rift.transform.rotation = Quaternion.Euler(intStartAngles.x + i, intStartAngles.y + j, intStartAngles.z);
            Debug.Log(string.Format("i: {0}, j: {1}, eulerangles: {2}", i, j, rift.transform.eulerAngles));
            // (...)
          }
          //It is safe here because you didn't manipulate the value,
          //but Quaternion.Euler is still more advisable
          rift.transform.eulerAngles = startAngles;
        }
      }
    }
