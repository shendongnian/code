    using System;
    using System.Windows.Forms;
    using System.Collections;
    using Photoshop;
    namespace PhotoShopCSharp2019
    {
    public partial class Form1 : Form
    {
        /// <summary>
        /// This file will contain methods to interface with Photoshop CC
        /// It uses the Adobe Photoshop CC 2014 Object Library (Using Photoshop)
        /// Code was modified from the 
        /// 2019 Photoshop Scripting Guide and Photoshop CC VBScript reference
        /// 
        /// https://www.adobe.com/devnet/photoshop/scripting.html
        /// The appRef object will be global indicating a single instance of Photoshop.
        /// The docref object will stay local to handle multiple images 
        /// being open simultaneously. 
        /// </summary>
        Photoshop.Application appRef = new Photoshop.Application();
        public Form1()
        {
            InitializeComponent();
        }
        private void HelloWorld() // page 19
        {
            // Modified from Page 19 of Script
            PsUnits originalRulerUnits = appRef.Preferences.RulerUnits;
            appRef.Preferences.RulerUnits = PsUnits.psInches;
            Document docRef = appRef.Documents.Add(2, 4);
            ArtLayer artLayerRef = docRef.ArtLayers.Add();
            artLayerRef.Kind = PsLayerKind.psTextLayer; //Normal Layer
            TextItem textItemRef = artLayerRef.TextItem;
            textItemRef.Contents = "Hello World";
            appRef.Preferences.RulerUnits = originalRulerUnits;
        }
        private Document OpenDocument(string sFile) // Page 29
        {
            Document docRef = appRef.Open(sFile);
            return docRef;
        }
        private void SavePDFDocument(string pdfFilename) // Page 30
        {
            PsUnits originalRulerUnits = appRef.Preferences.RulerUnits;
            appRef.Preferences.RulerUnits = PsUnits.psPixels;
            // Create a PDF option object
            PDFOpenOptions pdfOpenOptionsRef = new PDFOpenOptions();
            pdfOpenOptionsRef.AntiAlias = true;
            pdfOpenOptionsRef.Mode = PsOpenDocumentMode.psOpenRGB;
            pdfOpenOptionsRef.Resolution = 72;
            pdfOpenOptionsRef.Page = 3;
            Document docref = appRef.Open(pdfFilename, pdfOpenOptionsRef);
            //Restore Units
            appRef.Preferences.RulerUnits = originalRulerUnits;
        }
        private void SaveJpegDocument(string jpgFilename) // Page 32
        {
            PsUnits originalRulerUnits = appRef.Preferences.RulerUnits;
            appRef.Preferences.RulerUnits = PsUnits.psPixels;
            JPEGSaveOptions myJPEGOptions = new JPEGSaveOptions();
            myJPEGOptions.EmbedColorProfile = true;
            myJPEGOptions.FormatOptions = PsFormatOptionsType.psStandardBaseline;
            myJPEGOptions.Matte = PsMatteType.psNoMatte;
            myJPEGOptions.Quality = 1;
            appRef.ActiveDocument.SaveAs(jpgFilename, myJPEGOptions, true, PsExtensionType.psLowercase);
        }
        
        private void SomePreferences() // Holding place for various settings
        {
            appRef.Preferences.RulerUnits = PsUnits.psInches; // page 32
            appRef.Preferences.TypeUnits = PsTypeUnits.psTypePixels; // pag32
            appRef.DisplayDialogs = PsDialogModes.psDisplayNoDialogs; // page 33
        }
        private void PhotoResizeExample(string sFile) // Document Object Example page 35
        {
            PsUnits startRulerUnits = appRef.Preferences.RulerUnits;
            appRef.Preferences.RulerUnits = PsUnits.psInches;
            Document docRef = appRef.Open(sFile); 
            docRef.ResizeImage(4, 4);
            docRef.ResizeCanvas(4, 4);
            docRef.Trim(PsTrimType.psTopLeftPixel, true, false, true, false);
            appRef.Preferences.RulerUnits = PsUnits.psPixels;
            int[] MyArray = { 100, 200, 400, 500 };
            docRef.Crop(MyArray, 45, 20, 20);
            docRef.FlipCanvas(PsDirection.psHorizontal);
            // Restore units
            appRef.Preferences.RulerUnits = startRulerUnits;
        }
        private void CreateArtLayer() // Page 37
        {
            // This is akin to creating a new layer and first determining the layer type
 
            Document docref = appRef.Documents.Add();
            ArtLayer layerObj = appRef.ActiveDocument.ArtLayers.Add();
            layerObj.Name = "MyBlendLayer";
            layerObj.BlendMode = PsBlendMode.psNormalBlend;
            appRef.ActiveDocument.Selection.SelectAll();
            SolidColor ColorObj = new SolidColor();  // Color to be used with the fill command
            ColorObj.RGB.Red = 255;
            ColorObj.RGB.Green = 0;
            ColorObj.RGB.Blue = 0;
            // fill selection
            appRef.ActiveDocument.Selection.Fill(ColorObj);
         
        }
        private void CreateLayerSet() // page 38
        {
            appRef.Documents.Add();
            appRef.ActiveDocument.ArtLayers.Add();
            ArtLayer layerRef = appRef.ActiveDocument.Layers[1];
            // Create a new layer set
            LayerSet newLayerSetRef = appRef.ActiveDocument.LayerSets.Add();
            // Move the new layer to after the first layer
            newLayerSetRef.Move(newLayerSetRef, PsElementPlacement.psPlaceAfter);
        }
        private void DuplicateAndPlaceLayer() // Page 39
        {
            Document docref = appRef.Documents.Add();
            appRef.ActiveDocument.ArtLayers.Add();
            LayerSet layerSetRef = docref.LayerSets.Add();
            ArtLayer layerRef = docref.ArtLayers[1].Duplicate(layerSetRef, 2);
        }
        private void LinkingLayes() // Page 40
        {
            Document docref = appRef.Documents.Add();
            ArtLayer layer1Ref = docref.ArtLayers.Add();
            ArtLayer layer2Ref = docref.ArtLayers.Add();
            layer1Ref.Link(layer2Ref);
        }
        private void ApplyLayerStyle(Document docRef,string LayerName, string CaseSensitiveStyleName) // page 40
        {
            // Example uses a layer name of "L1" and a style named "Puzzle (Image)"
            LayerName = "L1";
            CaseSensitiveStyleName = "Puzzle (Image)";
            docRef.ArtLayers[LayerName].ApplyStyle(CaseSensitiveStyleName);
        }
        private void CreateTextLayer(Document docRef,string texLayerName, string MyText) // Page 41
        {
            ArtLayer newLayerRef = docRef.ArtLayers.Add();
            newLayerRef.Kind = PsLayerKind.psTextLayer;
            newLayerRef.Name = texLayerName;
            TextItem textItemRef = docRef.ArtLayers[texLayerName].TextItem;
            textItemRef.Contents = MyText;
            textItemRef.Justification = PsJustification.psRight;
        }
        private void MakeSelection() // Page 43
        {
            // Top Left ==> Origin
            // Ruler set to Pixels
            Document docRef = appRef.Documents.Add();
            int[,] shapeRef = { { 0, 0 }, { 100, 0 },{ 0, 100 },{ 100, 100 } };
            docRef.Selection.Select(shapeRef);
        }
        private void StrokeSelection() // Page 44
        {
            SolidColor strokeColor = new SolidColor();
            strokeColor.CMYK.Cyan = 20;
            strokeColor.CMYK.Magenta = 50;
            strokeColor.CMYK.Yellow = 30;
            strokeColor.CMYK.Black = 0;
            appRef.ActiveDocument.Selection.Stroke(strokeColor, 5, 1, 15, 75, false);
        }
        private void InvertExpandContractFeatherSelection()
        {
            Selection MySelection = appRef.ActiveDocument.Selection;
            PsUnits startRulerUnits = appRef.Preferences.RulerUnits;
            appRef.Preferences.RulerUnits = PsUnits.psPixels;
            MySelection.Invert();
            MySelection.Expand(5); //  5 pixels
            MySelection.Feather(5); // 5 pixels
            appRef.Preferences.RulerUnits = startRulerUnits;
        }
        private void FillSelection()  // Page 45
        {
            SolidColor fillColor = new SolidColor();
            fillColor.RGB.Red = 255;
            fillColor.RGB.Green = 0;
            fillColor.RGB.Blue = 0;
            Selection MySelection = appRef.ActiveDocument.Selection;
            MySelection.Fill(fillColor, 15, 25, false);
        }
        private void FillSelectionWithHistory(Document docRef, int myHistoryState)  // Page 45
        {
            Selection MySelection = appRef.ActiveDocument.Selection;
            MySelection.Fill(docRef.HistoryStates[myHistoryState]);
        }
        private void LoadAndStoreSelection(Document docRef) // Page 46
        {
            Channel chanRef = docRef.Channels.Add();
            chanRef.Name = "My Channel";
            chanRef.Kind = PsChannelType.psSelectedAreaAlphaChannel;
            docRef.Selection.Store(docRef.Channels["My Channel"], PsSelectionType.psExtendSelection);
        }
        private void RestoreSelection(Document docRef) // Page 46
        {
            Selection selRef = appRef.ActiveDocument.Selection;
            selRef.Load(docRef.Channels["My Channel"], PsSelectionType.psExtendSelection);
        }
        private void ChangeChannelType(Channel chanRef)  // Page 47
        {
            // Change to SpotColorChannel for example
            chanRef.Kind= PsChannelType.psSpotColorChannel;
        }
        private void DocumentInfo(Document docRef) // Page 47
        {
            DocumentInfo docInfoRef = docRef.Info;
            docInfoRef.Copyrighted = PsCopyrightedType.psCopyrightedWork;
            docInfoRef.OwnerUrl = "http://www.adobe.com";
        }
       
        private void MakeActiveHistoryState(Document docRef, int myHistoryState) // Page 48
        {
            docRef.ActiveHistoryState = docRef.HistoryStates[myHistoryState];
        }
        private void SaveCurrentFilter_HistoryState(Document docRef)
        {
            HistoryState savedState = docRef.ActiveHistoryState;
            docRef.ArtLayers[1].ApplyMotionBlur(20, 20); // Angle,Radius
            docRef.ActiveHistoryState = savedState;
        }
        private void Notifier()  // Page 49
        {
            appRef.NotifiersEnabled = true;
            string eventFile = appRef.Path + @"Presets\Scripts\Event Scripts Only\ Welcome.jax";
            appRef.Notifiers.Add("OPN ", eventFile);
        }
        private void PathObject() // Page 50
        {
            ArrayList lineArray = new ArrayList();
            int[] Point1 = { 100, 100 };
            int[] Point2 = { 150, 200 };
            Document docRef = appRef.Documents.Add(5000, 7000, 72, "Simple Line");
            PathPointInfo LineArray0 = new PathPointInfo();
            LineArray0.Kind = PsPointKind.psCornerPoint;
            LineArray0.Anchor = Point1;
            LineArray0.LeftDirection = LineArray0.Anchor;
            LineArray0.RightDirection = LineArray0.Anchor;
            PathPointInfo LineArray1 = new PathPointInfo();
            LineArray1.Kind = PsPointKind.psCornerPoint;
            LineArray1.Anchor = Point2;
            LineArray1.LeftDirection = LineArray1.Anchor;
            LineArray1.RightDirection = LineArray1.Anchor;
            lineArray.Add(LineArray0);
            lineArray.Add(LineArray1);
            SubPathInfo LineSubPathArray0 = new SubPathInfo();
            LineSubPathArray0.Operation = PsShapeOperation.psShapeXOR;
            LineSubPathArray0.Closed = false;
            LineSubPathArray0.EntireSubPath =lineArray;
            PathItem myPathItem = docRef.PathItems.Add("A Line", LineSubPathArray0);
            myPathItem.StrokePath(PsToolType.psBrush);
        }
        private void SetColor()  // Page 51
        {
            SolidColor solidColorRef = new SolidColor();
            solidColorRef.CMYK.Cyan = 20;
            solidColorRef.CMYK.Magenta = 90;
            solidColorRef.CMYK.Yellow = 50;
            solidColorRef.CMYK.Black = 50;
            appRef.ForegroundColor = solidColorRef;
        }
        private void ApplyGaussianBlur(Document docRef, int radius)
        {
            ArtLayer myLayer = docRef.ActiveLayer;
            myLayer.ApplyGaussianBlur(radius);
        }
        private void CopyMerged(Document docRef)
        {
            docRef.Selection.Copy(true);  // true ==> Merged
        }
        private void RunPhotoShopAction(string sFile,string ActionSet, string ActionName)
        {
            appRef.DisplayDialogs = PsDialogModes.psDisplayNoDialogs;
            appRef.Open(sFile);
            appRef.DoAction(ActionSet, ActionName);   // ActionSet,Action
            SaveJpegDocument(@"C:\Images\SavedFile.jpg");
            appRef.ActiveDocument.Close();
            //appRef.Quit();
            //appRef = null;
        }
    }
}
