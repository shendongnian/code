        if (eulerAngles.z > 45 && eulerAngles.z < 180)
        {
            transform.rotation = Quaternion.AngleAxis(-315, new Vector3(0, 0, 45));
            Debug.Log("45");
        }
        if (eulerAngles.z < 315 && eulerAngles.z > 180)
        {
            transform.rotation = Quaternion.AngleAxis(-315, new Vector3(0, 0, -45));
            Debug.Log("-45");
        }
