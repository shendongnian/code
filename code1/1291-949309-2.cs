    ...
    public Func<InputHelper, float> _horizontalCameraMovement = (InputHelper input) => 
    {
        return (input.LeftStickPosition.X * _moveRate) * _zoom;
    }
    public Func<InputHelper, float> _verticalCameraMovement = (InputHelper input) => 
    {
        return (-input.LeftStickPosition.Y * _moveRate) * _zoom;
    }
    ...
    public void Update(InputHelper input)
    {
        ...
        position += new Vector2(_horizontalCameraMovement(input), _verticalCameraMovement(input));
        ...
    }
