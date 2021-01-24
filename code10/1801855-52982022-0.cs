      public partial class Form7ImageOnly : Form
    {
     string file = "penguine.png";
     //  string file = "opentksquare.png";
       string file1 = "lambo2.png";
        int program;
        int vertShader;
        int fragShader;
        int buffer;
        int positionLocation;
        int positionLocation1;
                    int positionLocation2;
        int texture;
        int texture1;
        int ScreenWidth;
        int ScreenHeight;
        float[] vertices = {
                // Left bottom triangle
                -1f, -1f, 0f,
                1f, -1f, 0f,
                1f, 1f, 0f,
                // Right top triangle
                1f, 1f, 0f,
                  -1f, 1f, 0f,
                 -1f, -1f, 0f
        };
       
        public Form7ImageOnly()
        {
            InitializeComponent();
        }
        private void Form7ImageOnly_Load(object sender, EventArgs e)
        {
            glControl.Resize += new EventHandler(glControl_Resize);
            glControl.Paint += new PaintEventHandler(glControl_Paint);
            GL.ClearColor(Color.Yellow);
            GL.Enable(EnableCap.DepthTest);
            Application.Idle += Application_Idle;
            // Ensure that the viewport and projection matrix are set correctly.
            glControl_Resize(glControl, EventArgs.Empty);
        }
        void Application_Idle(object sender, EventArgs e)
        {
            while (glControl.IsIdle)
            {
                Render();
            }
        }
        private void Render()
        {
            ScreenWidth = Screen.PrimaryScreen.Bounds.Width;
            ScreenHeight = Screen.PrimaryScreen.Bounds.Height;
            glControl.Size = new System.Drawing.Size(ScreenWidth, ScreenHeight);//full screen
            texture = LoadTexture(file);
            texture1 = LoadTexture(file1);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            DrawImage(texture,texture1);
        }
        private void glControl_Paint(object sender, PaintEventArgs e)
        {
            Render();
        }
        private void glControl_Resize(object sender, EventArgs e)
        {
         Init();
        }
        private void Init()
        {
            CreateShaders();
            CreateProgram();
           InitBuffers();
        }
        public void DrawImage(int image,int image1)
        {
            GL.Viewport(new Rectangle(0, 0,  ScreenWidth, ScreenHeight));
            GL.MatrixMode(MatrixMode.Projection);
            GL.PushMatrix();
            GL.LoadIdentity();
            //GL.Ortho(0, 1920, 0, 1080, 0, 1);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.PushMatrix();
            GL.LoadIdentity();
            GL.Disable(EnableCap.Lighting);
            GL.Enable(EnableCap.Texture2D);
            GL.ActiveTexture(TextureUnit.Texture0);
            GL.BindTexture(TextureTarget.Texture2D, image);
            GL.Uniform1(positionLocation1, 0);
            GL.ActiveTexture(TextureUnit.Texture1);
            GL.BindTexture(TextureTarget.Texture2D, image1);
            GL.Uniform1(positionLocation2, 1);
            //GL.Begin(PrimitiveType.Quads);
            //GL.TexCoord2(0, 1);
            //GL.Vertex3(0, 0, 0);
            //GL.TexCoord2(1, 1);
            //GL.Vertex3(1920, 0, 0);
            //GL.TexCoord2(1, 0);
            //GL.Vertex3(1920, 1080, 0);
            //GL.TexCoord2(0, 0);
            //GL.Vertex3(0, 1080, 0);
            //GL.End();
            RunShaders();
            GL.Disable(EnableCap.Texture2D);
            GL.PopMatrix();
            GL.MatrixMode(MatrixMode.Projection);
            GL.PopMatrix();
            GL.MatrixMode(MatrixMode.Modelview);
            ErrorCode ec = GL.GetError();
            if (ec != 0)
                System.Console.WriteLine(ec.ToString());
            Console.Read();
            glControl.SwapBuffers();
        }
        private void RunShaders()
        {
            GL.ClearColor(Color.Yellow);
            GL.UseProgram(program);
            GL.DrawArrays(PrimitiveType.Triangles, 0, vertices.Length / 3);
            ErrorCode ec = GL.GetError();
            if (ec != 0)
                System.Console.WriteLine(ec.ToString());
            Console.Read();
        }
        private void CreateProgram()
        {
            program = GL.CreateProgram();
            GL.AttachShader(program, vertShader);
            GL.AttachShader(program, fragShader);
            GL.LinkProgram(program);
        }
        private void CreateShaders()
        {
            /***********Vert Shader********************/
            vertShader = GL.CreateShader(ShaderType.VertexShader);
            GL.ShaderSource(vertShader, @"attribute vec3 a_position;
                                        varying vec2 vTexCoord;
                                        void main() {
                                        vTexCoord = (a_position.xy + 1) / 2;
                                        gl_Position = vec4(a_position, 1);
                                        }");
            GL.CompileShader(vertShader);
            /***********Frag Shader ****************/
            fragShader = GL.CreateShader(ShaderType.FragmentShader);
            GL.ShaderSource(fragShader, @"precision highp float;
        uniform sampler2D sTexture;uniform sampler2D sTexture1;
                                       varying vec2 vTexCoord;
                                 void main ()
                                 {
                                     vec4    color   = texture2D (sTexture, vTexCoord);
                                     vec4 color1=texture2D (sTexture1, vTexCoord);
                                  //  if(color.r < 0.3){color.r = 1.0;}
                                  //  Save the result
                                  // gl_FragColor    = color;
                                  if(vTexCoord.y<0.5)
                                 gl_FragColor = color1;
                                  else
                              gl_FragColor    = color;
                              //  gl_FragColor    =vec4(1.0,0.0,0.0,1.0);
                                 }");
            GL.CompileShader(fragShader);
        }
        private void InitBuffers()
        {
            buffer = GL.GenBuffer();
            positionLocation = GL.GetAttribLocation(program, "a_position");
            positionLocation1 = GL.GetUniformLocation(program, "sTexture");
            positionLocation2 = GL.GetUniformLocation(program, "sTexture1");
            GL.EnableVertexAttribArray(positionLocation);
            GL.BindBuffer(BufferTarget.ArrayBuffer, buffer);
            GL.BufferData(BufferTarget.ArrayBuffer, (IntPtr)(vertices.Length * sizeof(float)), vertices, BufferUsageHint.StaticDraw);
            GL.VertexAttribPointer(positionLocation, 3, VertexAttribPointerType.Float, false, 0, 0);
        }
       
        public int LoadTexture(string file)
        {
            Bitmap bitmap = new Bitmap(file);
            int tex = -1;
            if (bitmap != null)
            {
               GL.DeleteTextures(1, ref tex);
                GL.Hint(HintTarget.PerspectiveCorrectionHint, HintMode.Nicest);
             GL.GenTextures(1, out tex);
             GL.BindTexture(TextureTarget.Texture2D, tex);
                bitmap.RotateFlip(RotateFlipType.RotateNoneFlipY);
                BitmapData data = bitmap.LockBits(new System.Drawing.Rectangle(0, 0, bitmap.Width, bitmap.Height),
               ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba,data.Width,data.Height, 0,
                OpenTK.Graphics.OpenGL.PixelFormat.Bgra, PixelType.UnsignedByte, data.Scan0);
                bitmap.UnlockBits(data);
                GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Linear);
                GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Linear);
                GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapS, (int)TextureWrapMode.ClampToEdge);
                GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapT, (int)TextureWrapMode.ClampToEdge);
            }
            return tex;
        }
      
    }
