    rb.AddForce(10, ForceMode.Impulse); // add instant force, using mass
    // Or
    rb.AddForce(10, ForceMode.VelocityChange); // add instant force, ignoring mass
    // Or
    rb.AddForce(10, ForceMode.Force); // add continuous force, using mass
    // Or
    rb.AddForce(10, ForceMode.Acceleration); // add continous force, ignoring mass
