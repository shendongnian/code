    public interface I2DComponent
    {
        /// <summary>
        /// Gets or sets the local (world) bounds of the object.
        /// </summary>
        /// <value>The rectangle.</value>
        Rectangle Bounds{ get; }
        
        /// <summary>
        /// Gets or sets the scale.
        /// </summary>
        /// <value>The scale.</value>
        float Scale { get; set; }
    }
