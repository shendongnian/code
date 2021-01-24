    // Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 
    'UnityObjectToClipPos(*)'
    Shader "Programmer/Fur Shader"
    {
    Properties
    {
        _MainTex("Texture", 2D) = "white" {}
    _TintColor("Tint Color", Color) = (1,1,1,1)
    }
    SubShader
    {
        Tags{ "Queue" = "Transparent" "RenderType" = "Transparent" }
        LOD 100
        //Blend SrcAlpha One
        //Blend DstAlpha OneMinusSrcAlpha
        Blend SrcAlpha OneMinusSrcAlpha
        ZWrite Off
        Cull Off
        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
                    // make fog work
                    //#pragma multi_compile_fog
            #include "UnityCG.cginc"
            //In
            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };
        //Out
            struct v2f
            {
                float2 uv : TEXCOORD0;
                UNITY_FOG_COORDS(1)
                    float4 vertex : SV_POSITION;
            };
            struct VertexShaderInput
            {
                float3 Position : POSITION0;
                float3 Normal : NORMAL0;
                float2 TexCoord : TEXCOORD0;
            };
            struct VertexShaderOutput
            {
                float4 Position : POSITION0;
                float2 TexCoord : TEXCOORD0;
                float4 Tint: COLOR1;
            };
            sampler2D _MainTex;
            float4 _MainTex_ST;
            //Test variable/delete after
            float4 _TintColor;
            //The variables
            float4x4 World;
            float4x4 View;
            float4x4 Projection;
            float CurrentLayer; //value between 0 and 1
            float MaxHairLength; //maximum hair length
            VertexShaderOutput vert(VertexShaderInput input)
            {
                VertexShaderOutput output;
                float3 pos;
                pos = input.Position + input.Normal * MaxHairLength * CurrentLayer;
                //float4 worldPosition = mul(float4(pos, 1), World);
                //float4 viewPosition = mul(worldPosition, View);
                output.Position = UnityObjectToClipPos(pos);
                output.TexCoord = input.TexCoord;
                output.Tint = float4(CurrentLayer, CurrentLayer, 0, 1);
                return output;
            }
            float4 frag(VertexShaderOutput  i) : COLOR0
            {
                float4 t = tex2D(_MainTex,  i.TexCoord) * i.Tint;
                return t;//float4(t, i.x, i.y, 1);
            }
            ENDCG
        }
    }
