            if (rb.position.y >= 10f)
            {
                SAF = false;
                rb.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ;  
                break; //break the loop since condition is met
            }
            else
            {
                rb.AddForce(0, VerticalForce * Time.deltaTime, 0);
                continue; //the condition is not met, so the loop goes on
            }
        }
