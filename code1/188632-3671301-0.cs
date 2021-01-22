    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Windows.Forms;
    using System.Drawing;
    using System.IO;
    using System.Reflection;
    using Polygon;
    using STL;
    using Microsoft.DirectX;
    using Microsoft.DirectX.Direct3D;
    
    namespace STLView
    {
        public class STLViewer : Form
        {
            #region Private Members
    
            #region DirectX Objects
    
            /// <summary>
            /// DirectX Device object that will allow us to perform drawing
            /// </summary>
            private Device directXDevice = null;
    
            /// <summary>
            /// Array of vertices that will hold our Polygon vertices
            /// </summary>
            private static CustomVertex.PositionColored[] verts;
    
            #endregion
    
            #region STL Viewer Specific Objects
    
            /// <summary>
            /// String to hold the name of the path in the assembly for our form icon
            /// </summary>
            private static string icon = "STLView.Resources.Symbol17.ico";
    
            /// <summary>
            /// STLFile object that will be used to draw the object
            /// </summary>
            public static STLFile stlFile;
    
            #endregion
    
            #endregion
    
            #region Public Members
    
            /// <summary>
            /// Default Constructor.
            /// </summary>
            public STLViewer()
            {
                // Set the form size, form text, icon
                this.ClientSize = new Size(800, 600);
                this.Text = "Object Name: " + stlFile.SolidName + ", Polygon Count: " + stlFile.GetPolygons().Count;
                this.Icon = RetrieveFormIcon();
    
                // Change our drawing style so there is no drawing happening outside our main form
                this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.Opaque, true);
    
                // Get our vertex data in a prepared format
                verts = PrepareObjectForRender();
            }
    
            /// <summary>
            /// This function is responsible for retrieving the specified
            /// icon from the assembly.
            /// </summary>
            /// <returns>Form icon</returns>
            private Icon RetrieveFormIcon()
            {
                Assembly assembly = Assembly.GetExecutingAssembly();
                Stream str = assembly.GetManifestResourceStream(icon);
    
                return new Icon(str);
            }
    
            #endregion
    
            #region Main Line
    
            public static void Main()
            {
                // Create our form object
                STLViewer stlViewer = new STLViewer();
    
                // Initialize D3D
                if (stlViewer.InitializeDirect3D() == false)
                {
                    MessageBox.Show("Could not initialize Direct3D.", "Error");
                    return;
                }
    
                // Display our form
                stlViewer.Show();
    
                // Main message loop
                while (stlViewer.Created)
                {
                    // Handle aall events here: keyboard, mouse, etc.
                    Application.DoEvents();
                }
            }
    
            #endregion
    
            #region Rendering
    
            /// <summary>
            /// This function is the overloaded OnPaint method, which is responsible
            /// for drawing our scene.
            /// </summary>
            /// <param name="e"></param>
            protected override void OnPaint(PaintEventArgs e)
            {
                // IF we have a forced switch to Solid mode switch to Wireframe
                if (directXDevice.RenderState.FillMode == FillMode.Solid)
                {
                    directXDevice.RenderState.FillMode = FillMode.WireFrame;
                }
    
                // Clear the window to black
                directXDevice.Clear(ClearFlags.Target, Color.Navy, 1.0f, 0);
    
                // Disable culling
                directXDevice.RenderState.CullMode = Cull.None;
    
                // Setup the camera for viewing
                SetupCamera();
    
                // Begin the rendering process
                directXDevice.BeginScene();
    
                // Set the vertext format
                directXDevice.VertexFormat = CustomVertex.PositionColored.Format;
    
                // Draw our vertices
                directXDevice.DrawUserPrimitives(PrimitiveType.TriangleList, stlFile.GetPolygons().Count, verts);
    
                // End rendering and present the drawing to the screen
                directXDevice.EndScene();
                directXDevice.Present();
    
                // Force our form to refresh its viewing area
                this.Invalidate();
            }
    
            /// <summary>
            /// This function is responsible for creating the necessary
            /// DirectX objects, setting the vertices and normals, colors
            /// and/or materials for the object so we can draw it in the
            /// form.
            /// </summary>
            private CustomVertex.PositionColored[] PrepareObjectForRender()
            {
                // List to hold our colored vertices
                List<CustomVertex.PositionColored> vertices = new List<CustomVertex.PositionColored>();
    
                // List to hold our polygons, contained within the STL file
                List<Polygon.Polygon> polygons = stlFile.GetPolygons();
    
                // Create a custom vertex that will be used to hold our vertices
                CustomVertex.PositionColored custVert = new CustomVertex.PositionColored();
    
                // Iterate through our polygons and pulled a vertex list
                for (int i = 0; i < polygons.Count; i++)
                {
                    // Set the position and color of our 1st vertex in our polygon, add it to our list
                    custVert.Position = new Vector3((float)polygons[i].GetDoublePoints1()[0],
                        (float)polygons[i].GetDoublePoints1()[1], (float)polygons[i].GetDoublePoints1()[2]);
                    custVert.Color = Color.YellowGreen.ToArgb();
                    vertices.Add(custVert);
    
                    // Set the position and color of our 2nd vertex in our polygon, add it to our list
                    custVert.Position = new Vector3((float)polygons[i].GetDoublePoints2()[0],
                        (float)polygons[i].GetDoublePoints2()[1], (float)polygons[i].GetDoublePoints2()[2]);
                    custVert.Color = Color.YellowGreen.ToArgb();
                    vertices.Add(custVert);
    
                    // Set the position and color of our 3rd vertex in our polygon, add it to our list
                    custVert.Position = new Vector3((float)polygons[i].GetDoublePoints3()[0],
                        (float)polygons[i].GetDoublePoints3()[1], (float)polygons[i].GetDoublePoints3()[2]);
                    custVert.Color = Color.YellowGreen.ToArgb();
                    vertices.Add(custVert);
                }
    
                // Cast our list to an array of vertices
                CustomVertex.PositionColored[] verts = vertices.ToArray();
    
                return verts;
            }
    
            #endregion
    
            #region Initialization & Configuration
    
            /// <summary>
            /// This function is responsible for initializing our Direct3D device.
            /// </summary>
            /// <returns>TRUE if successful, FALSE if not</returns>
            private bool InitializeDirect3D()
            {
                bool retVal = false;
    
                // TRY to create our Direct3D device
                // CATCH and report any errors
                try
                {
                    #region Present Parameters
    
                    // Create a new PresentParameters object so our device knows how to display
                    PresentParameters pps = new PresentParameters();
    
                    // Display in a windowed mode
                    pps.Windowed = true;
    
                    // After the current screen is draw, discard it from memory
                    pps.SwapEffect = SwapEffect.Discard;
    
                    // No Z (Depth) buffer or Stencil buffer
                    pps.EnableAutoDepthStencil = false;
    
                    // 1 Back buffer for double-buffering
                    pps.BackBufferCount = 1;
    
                    // Set our back buffer dimensions and format
                    pps.BackBufferHeight = 0;
                    pps.BackBufferWidth = 0;
                    pps.BackBufferFormat = Format.Unknown;
    
                    #endregion
    
                    // Create the new D3D Device and set our PresentParameters within
                    directXDevice = new Device(0, DeviceType.Hardware, this,
                        CreateFlags.SoftwareVertexProcessing, pps);
    
                    // Use wireframe as our drawing mode
                    directXDevice.RenderState.FillMode = FillMode.WireFrame;
    
                    retVal = true;
                }
                catch (DirectXException e)
                {
                    // Display our error message
                    MessageBox.Show(e.ToString(), "Error");
                }
    
                return retVal;
            }
    
            #endregion
    
            #region Camera
            
            /// <summary>
            /// This function is responsible for setting up the camera.
            /// </summary>
            private void SetupCamera()
            {
                #region View Matrix
    
                // This is the camera location and is commonly referred to as the "eye point"
                Vector3 eyeVector = new Vector3(0.0f, 0.0f, -500.0f);
    
                // The Look At Vector defines the point that the camera is aimed at
                Vector3 lookAtVector = new Vector3(0, 0, 0);
    
                // The "up" direction is the positive direction on the y-axis
                Vector3 upVector = new Vector3(0, 1, 0);
    
                // Register our View Matrix so it can be used to place and aim our camera
                directXDevice.Transform.View = Matrix.LookAtLH(eyeVector,
                    lookAtVector, upVector);
    
                #endregion
    
                #region Projection Matrix
    
                //45 degree field of view
                float fieldOfView = (float)Math.PI / 4.0f;
    
                //Typical aspect ratio is approximately 1.333...
                float aspectRatio = (float)ClientSize.Width / ClientSize.Height;
    
                // Register our Projection Matrix so it can be used for viewing items in
                // front of the camera
                directXDevice.Transform.Projection = Matrix.PerspectiveFovLH(fieldOfView,
                    aspectRatio, 1.0f, 1000.0f);
    
                #endregion
    
                #region World Matrix
    
                // Create a scaling matrix
                Matrix scaleMatrix = Matrix.Scaling(0.5f, 0.5f, 0.5f);
    
                // World Matrix = Scaling Matrix
                directXDevice.Transform.World = scaleMatrix;
    
                #endregion
    
                #region Lighting
    
                // Enable/Disable lighting
                directXDevice.RenderState.Lighting = false;
    
                #endregion
            }
    
            #endregion
        }
    }
