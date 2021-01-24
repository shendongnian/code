    void Update(float gameTime) {
            Vector3 camTransform = Camera.Position + cameraTarget;
            Vector3 newCameraPosition = Vector3.Slerp(cameraPosition, camTransform, 0.2f);
            Camera.Position = newCameraPosition;
    }
