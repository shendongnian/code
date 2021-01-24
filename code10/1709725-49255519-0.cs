        //Here, switching modes depend on button presses in the Game mode
        switch (m_ModeSwitching)
        {
            //This is the starting mode which resets the GameObject
            case ModeSwitching.Start:
                //This resets the GameObject and Rigidbody to their starting positions
                transform.position = m_StartPos;
                m_Rigidbody.transform.position = m_StartForce;
                //This resets the velocity of the Rigidbody
                m_Rigidbody.velocity = new Vector3(0f, 0f, 0f);
                break;
            //These are the modes ForceMode can force on a Rigidbody
            //This is Acceleration mode
            case ModeSwitching.Acceleration:
                //The function converts the text fields into floats and updates the Rigidbody’s force
                MakeCustomForce();
                //Use Acceleration as the force on the Rigidbody
                m_Rigidbody.AddForce(m_NewForce, ForceMode.Acceleration);
                break;
            //This is Force Mode, using a continuous force on the Rigidbody considering its mass
            case ModeSwitching.Force:
                //Converts the text fields into floats and updates the force applied to the Rigidbody
                MakeCustomForce();
                //Use Force as the force on GameObject’s Rigidbody
                m_Rigidbody.AddForce(m_NewForce, ForceMode.Force);
                break;
            //This is Impulse Mode, which involves using the Rigidbody’s mass to apply an instant impulse force.
            case ModeSwitching.Impulse:
                //The function converts the text fields into floats and updates the force applied to the Rigidbody
                MakeCustomForce();
                //Use Impulse as the force on GameObject
                m_Rigidbody.AddForce(m_NewForce, ForceMode.Impulse);
                break;
            //This is VelocityChange which involves ignoring the mass of the GameObject and impacting it with a sudden speed change in a direction
            case ModeSwitching.VelocityChange:
                //Converts the text fields into floats and updates the force applied to the Rigidbody
                MakeCustomForce();
                //Make a Velocity change on the Rigidbody
                m_Rigidbody.AddForce(m_NewForce, ForceMode.VelocityChange);
                break;
        }
